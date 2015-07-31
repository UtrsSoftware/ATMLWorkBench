/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

template < class T > class Tree
{
private:

	template< class T > class TreeNode
	{ 
	public:
	
		TreeNode( const T& data ) { Init( ); m_Data = data; }
		TreeNode( ) { Init( ); }
		
		TreeNode< T >* m_pParent;
		TreeNode< T >* m_pFirstChild;
		TreeNode< T >* m_pLastChild;
		TreeNode< T >* m_pPrevSibling;
		TreeNode< T >* m_pNextSibling;
		T m_Data;
	
		void Init( void )
		{
			m_pParent		= 0;
			m_pFirstChild	= 0;
			m_pLastChild	= 0;
			m_pPrevSibling	= 0;
			m_pNextSibling	= 0;
		}
	};

public:

	typedef unsigned int iteratorHash;

	class iterator
	{ 
	public:

		iterator( ) : m_pTreeNode( 0 ) { }
		iterator( const iteratorHash& ith ) : m_pTreeNode( ( TreeNode< T >* ) ith ) { }
		iterator( const iterator& itOther ) { operator = ( itOther ); }

		bool isValid( void ) const { return ( 0 != m_pTreeNode ); }

		bool isParent( void ) const
		{
			bool bIsParent = false;

			if ( 0 != m_pTreeNode )
			{
				if ( 0 != m_pTreeNode->m_pFirstChild )
				{
					bIsParent = true;
				}
			}

			return bIsParent;
		}

		iteratorHash hash( void ) const { return ( iteratorHash ) m_pTreeNode; }

		// Number of siblings if bChildren is false, otherwise children size.
		// Use method isParent to determine if there is children (its quicker than getting a count)
		unsigned int size( const bool bChildren = false ) const
		{
			unsigned int uiRet = 0;

			if ( 0 != m_pTreeNode )
			{
				if ( bChildren )
				{
					if ( 0 != m_pTreeNode->m_pFirstChild )
					{
						TreeNode< T >* pNode = m_pTreeNode->m_pFirstChild;
	
						++uiRet;
	
						while ( 0 != pNode->m_pNextSibling )
						{
							++uiRet;
	
							pNode = pNode->m_pNextSibling;
						}
					}
				}
				else
				{
					TreeNode< T >* pNode = m_pTreeNode;
			
					++uiRet;

					while ( 0 != pNode->m_pNextSibling )
					{
						++uiRet;

						pNode = pNode->m_pNextSibling;
					}

					pNode = m_pTreeNode;
			
					while ( 0 != pNode->m_pPrevSibling )
					{
						++uiRet;

						pNode = pNode->m_pPrevSibling;
					}
				}
			}

			return uiRet;
		}

		// If no children, returned iterator method isValid will be false.
		iterator firstChild( void ) const
		{
			iterator it;

			if ( 0 != m_pTreeNode )
			{
				it.m_pTreeNode = m_pTreeNode->m_pFirstChild;
			}

			return it;
		}

		// If no children, returned iterator method isValid will be false.
		iterator lastChild( void ) const
		{
			iterator it;

			if ( 0 != m_pTreeNode )
			{
				it.m_pTreeNode = m_pTreeNode->m_pLastChild;
			}

			return it;
		}

		iterator& operator = ( const iteratorHash& ith ) { m_pTreeNode = ( ( TreeNode< T >* ) ) ith; return *this; }

		iterator& operator = ( const iterator& itOther ) { if ( this != &itOther ) { m_pTreeNode = itOther.m_pTreeNode; } return *this; }

		T& operator * ( ) const { return m_pTreeNode->m_Data; }

		T* operator -> ( ) const { return &( m_pTreeNode->m_Data ); }

		bool operator == ( const iterator& itOther ) const { return ( m_pTreeNode == itOther->m_pTreeNode ); }

		bool operator != ( const iterator& itOther ) const { return ( m_pTreeNode != itOther.m_pTreeNode ); }

		iterator& operator ++ ( ) { if ( 0 != m_pTreeNode ) { m_pTreeNode = m_pTreeNode->m_pNextSibling; } return *this; }

		iterator& operator -- ( ) { if ( 0 != m_pTreeNode ) { m_pTreeNode = m_pTreeNode->m_pPrevSibling; } return *this; }

		iterator operator ++ ( int ) { iterator itCopy( *this ); ++( *this ); return itCopy; }

		iterator operator -- ( int ) { iterator itCopy( *this ); --( *this ); return itCopy; }

	protected:

		iterator( TreeNode< T >* pTreeNode ) : m_pTreeNode( pTreeNode ) { }

		TreeNode< T >* m_pTreeNode;

		friend class Tree;
	};

	enum ePosition
	{
		eFirst,
		eLast,
		ePrevious,
		eNext
	};

	enum eRelationship
	{
		eChild,
		eSibling
	};

	Tree( ) : m_pFirstNode( 0 ), m_pLastNode( 0 ), m_uiSize( 0 ) { }
	~Tree( ) { GarbageCollect( m_pFirstNode ); }

	iterator begin( void ) const { return iterator( m_pFirstNode ); }
	iterator end( void ) const { return iterator( ); }
	iterator last( void ) const { return iterator( m_pLastNode ); }

	unsigned int size( void ) const { return m_uiSize; }

	void erase( iterator itItem, const bool bChildrenOnly )
	{
		if ( itItem.isValid( ) )
		{
			TreeNode< T >* pExistingTreeNode = ( TreeNode< T >* ) itItem.m_pTreeNode;

			if ( ( 0 != pExistingTreeNode->m_pFirstChild ) )
			{
				GarbageCollect( pExistingTreeNode->m_pFirstChild );

				pExistingTreeNode->m_pFirstChild = 0;
				pExistingTreeNode->m_pLastChild = 0;
			}

			if ( !bChildrenOnly )
			{
				TreeNode< T >** pFirst = 0;
				TreeNode< T >** pLast = 0;
				bool bSwap = true;

				if ( 0 != pExistingTreeNode->m_pParent )
				{
					if ( pExistingTreeNode == pExistingTreeNode->m_pParent->m_pFirstChild )
					{
						pFirst = &( pExistingTreeNode->m_pParent->m_pFirstChild );
					}

					if ( pExistingTreeNode == pExistingTreeNode->m_pParent->m_pLastChild )
					{
						pLast = &( pExistingTreeNode->m_pParent->m_pLastChild );
					}
				}								  
				else
				{
					if ( m_pFirstNode == pExistingTreeNode )
					{
						pFirst = &( m_pFirstNode );
					}

					if ( m_pLastNode == pExistingTreeNode )
					{
						pLast = &( m_pLastNode );
					}
				}

				if ( 0 != pFirst )
				{
					if ( 0 != pLast )
					{
						*pFirst = 0;
						*pLast = 0;

						pLast = 0;
						bSwap = false;
					}
					else
					{
						pExistingTreeNode->m_pNextSibling->m_pPrevSibling = 0;
						*pFirst = pExistingTreeNode->m_pNextSibling;
					}
				}

				if ( 0 != pLast )
				{
					pExistingTreeNode->m_pPrevSibling->m_pNextSibling = 0;
					*pLast = pExistingTreeNode->m_pPrevSibling;
				}
				else if ( bSwap )
				{
					if ( 0 != pExistingTreeNode->m_pPrevSibling )
					{
						pExistingTreeNode->m_pPrevSibling->m_pNextSibling = pExistingTreeNode->m_pNextSibling;
					}

					if ( 0 != pExistingTreeNode->m_pNextSibling )
					{
						pExistingTreeNode->m_pNextSibling->m_pPrevSibling = pExistingTreeNode->m_pPrevSibling;
					}
				}

				delete pExistingTreeNode;
				--m_uiSize;
			}
		}
	}

	iterator insert( const iterator& itItem, const T& data, const eRelationship eRelate = eSibling, const ePosition ePos = eNext )
	{
		TreeNode< T >* pExistingTreeNode = ( TreeNode< T >* ) itItem.m_pTreeNode;
		TreeNode< T >* pNewTreeNode = 0;

		if ( 0 == pExistingTreeNode )
		{
			pExistingTreeNode = m_pFirstNode;
		}

		try
		{
			pNewTreeNode = new TreeNode< T >( data );
		}
		catch ( ... )
		{
			// Not handling low/no memory condition.
			// Not sure what to do...
		}

		if ( 0 != pNewTreeNode )
		{
			if ( eChild == eRelate )
			{
				pNewTreeNode->m_pParent = pExistingTreeNode;
	
				if ( 0 == pExistingTreeNode->m_pFirstChild )
				{
					pExistingTreeNode->m_pFirstChild = pNewTreeNode;
					pExistingTreeNode->m_pLastChild = pNewTreeNode;
				}
				else
				{
					switch ( ePos )
					{
						case eFirst:
						case ePrevious:
							InsertBefore( pExistingTreeNode->m_pFirstChild, pNewTreeNode );
							break;
			
						case eLast:
						case eNext:
							InsertAtEnd( pExistingTreeNode->m_pLastChild, pNewTreeNode );
							break;
					}
				}
			}
			else
			{
				if ( 0 != pExistingTreeNode )
				{
					pNewTreeNode->m_pParent = pExistingTreeNode->m_pParent;
				}

				switch ( ePos )
				{
					case ePrevious:
						InsertBefore( pExistingTreeNode, pNewTreeNode );
						break;
		
					case eNext:
						InsertAfter( pExistingTreeNode, pNewTreeNode );
						break;
		
					case eFirst:
						InsertAtBegin( pExistingTreeNode, pNewTreeNode );
						break;
		
					case eLast:
						InsertAtEnd( pExistingTreeNode, pNewTreeNode );
						break;
		
				}
			}

			++m_uiSize;
		}

		return iterator( pNewTreeNode );
	}

private:

	void InsertAtBegin( TreeNode< T >* pTreeNode, TreeNode< T >* pNewTreeNode )
	{
		if ( 0 == pTreeNode )
		{
			m_pFirstNode = pNewTreeNode;
			m_pLastNode = pNewTreeNode;
		}
		else
		{
			if ( 0 == pTreeNode->m_pParent )
			{
				pNewTreeNode->m_pNextSibling = m_pFirstNode;
				m_pFirstNode->m_pPrevSibling = pNewTreeNode;
				m_pFirstNode = pNewTreeNode;
			}
			else
			{
				pNewTreeNode->m_pNextSibling = pTreeNode->m_pParent->m_pFirstChild;
				pTreeNode->m_pParent->m_pFirstChild->m_pPrevSibling = pNewTreeNode;
				pTreeNode->m_pParent->m_pFirstChild = pNewTreeNode;
			}
		}
	}

	void InsertAtEnd( TreeNode< T >* pTreeNode, TreeNode< T >* pNewTreeNode )
	{
		if ( 0 == pTreeNode )
		{
			m_pFirstNode = pNewTreeNode;
			m_pLastNode = pNewTreeNode;
		}
		else
		{
			if ( 0 == pTreeNode->m_pParent )
			{
				m_pLastNode->m_pNextSibling = pNewTreeNode;
				pNewTreeNode->m_pPrevSibling = m_pLastNode;
				m_pLastNode = pNewTreeNode;
			}
			else
			{
				pNewTreeNode->m_pPrevSibling = pTreeNode->m_pParent->m_pLastChild;
				pTreeNode->m_pParent->m_pLastChild->m_pNextSibling = pNewTreeNode;
				pTreeNode->m_pParent->m_pLastChild = pNewTreeNode;
			}
		}
	}

	void InsertBefore( TreeNode< T >* pTreeNode, TreeNode< T >* pNewTreeNode )
	{
		bool bInsertAtBegin = false;

		if ( 0 != pTreeNode )
		{
			if ( 0 == pTreeNode->m_pParent )
			{
				if ( m_pFirstNode == pTreeNode )
				{
					bInsertAtBegin = true;
				}
			}
			else if ( pTreeNode == pTreeNode->m_pParent->m_pFirstChild )
			{
				bInsertAtBegin = true;
			}
		}
		else
		{
			bInsertAtBegin = true;
		}

		if ( bInsertAtBegin )
		{
			InsertAtBegin( pTreeNode, pNewTreeNode );
		}
		else
		{
			pNewTreeNode->m_pNextSibling = pTreeNode;
			pNewTreeNode->m_pPrevSibling = pTreeNode->m_pPrevSibling;
			pTreeNode->m_pPrevSibling->m_pNextSibling = pNewTreeNode;
			pTreeNode->m_pPrevSibling = pNewTreeNode;
		}
	}

	void InsertAfter( TreeNode< T >* pTreeNode, TreeNode< T >* pNewTreeNode )
	{
		bool bInsertAtEnd = false;

		if ( 0 != pTreeNode )
		{
			if ( 0 == pTreeNode->m_pParent )
			{
				if ( m_pLastNode == pTreeNode )
				{
					bInsertAtEnd = true;
				}
			}
			else if ( pTreeNode == pTreeNode->m_pParent->m_pLastChild )
			{
				bInsertAtEnd = true;
			}
		}
		else
		{
			bInsertAtEnd = true;
		}

		if ( bInsertAtEnd )
		{
			InsertAtEnd( pTreeNode, pNewTreeNode );
		}
		else
		{
			pNewTreeNode->m_pPrevSibling = pTreeNode;
			pNewTreeNode->m_pNextSibling = pTreeNode->m_pNextSibling;
			pTreeNode->m_pNextSibling = pNewTreeNode;
			pNewTreeNode->m_pNextSibling->m_pPrevSibling = pTreeNode;
		}
	}

	void GarbageCollect( TreeNode< T >* pTreeNode )
	{
		if ( 0 != pTreeNode )
		{
			TreeNode< T >* pTempNode1 = pTreeNode;
			TreeNode< T >* pTempNode2 = 0;
	
			while ( 0 != pTempNode1->m_pNextSibling )
			{
				if ( 0 != pTempNode1->m_pFirstChild )
				{
					GarbageCollect( pTempNode1->m_pFirstChild );
				}

				pTempNode2 = pTempNode1->m_pNextSibling;
	
				delete pTempNode1;
				--m_uiSize;
	
				pTempNode1 = pTempNode2;
			}
	
			if ( 0 != pTempNode1->m_pFirstChild )
			{
				GarbageCollect( pTempNode1->m_pFirstChild );
			}

			delete pTempNode1;
			--m_uiSize;

			if ( m_pFirstNode == pTreeNode )
			{
				m_pFirstNode = 0;
				m_pLastNode = 0;
			}
		}
	}

	TreeNode< T >* m_pFirstNode;
	TreeNode< T >* m_pLastNode;
	unsigned int m_uiSize;
};